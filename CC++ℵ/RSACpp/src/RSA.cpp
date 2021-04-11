#include "RSA.h"



RSA::RSA()
{
	fmt::print("Enter first prime number\n");
	std::cin >> m_p;

	while (!Utility::checkIfPrime(m_p))
	{
		fmt::print("Your first number is not prime please reenter it\n");
		std::cin >> m_p;
	}

	fmt::print("Enter second prime number\n");
	std::cin >> m_q;

	while (!Utility::checkIfPrime(m_q) || m_q == m_p)
	{
		fmt::print("Your second number is not prime or it is the same as the first please reenter it\n");
		std::cin >> m_q;
	}

	fmt::print("Enter the message\n");
	std::cin >> m_originalMessage;

	m_originalMessageAscii = Utility::convertStringToBytes(m_originalMessage);

	m_n = m_p * m_q;
	m_phi = (m_p - 1) * (m_q - 1);

	generateKeys();

	Encrypt();
	int x = 5;

	Utility::createDirectory(rootFolder, Utility::hashish(m_encryptedMessage));
	createEncryptedPackets();
}

RSA::RSA(std::u32string encryptedMessage,long long int n, std::vector<long long int> privateKey)
	:m_encryptedMessage(encryptedMessage), m_n(n)
{
	//m_Key.privateKey;
	m_encryptedMessageAscii = Utility::convertU32StringToBytes(m_encryptedMessage);
	m_Key.privateKey = privateKey;
	int x = 5;
	Decrypt();
}

RSA::~RSA()
{

}

void RSA::generateKeys()
{

	int position = 0;

	for (int i = 2; i < m_phi; i++)
	{
		if (m_phi % i == 0)
		{
			continue;
		}

		if (Utility::checkIfPrime(i) && i != m_p && i != m_q)
		{
			m_Key.privateKey.push_back(i);
			int flag = Utility::cd(m_Key.privateKey[position], m_phi);
			if (flag > 0)
			{
				m_Key.publicKey.push_back(flag);
				position++;
			}
			if (position == 50)
			{
				break;
			}
		}
	}
}

void RSA::Encrypt()
{
	m_encryptedMessageAscii.clear();
	unsigned long long int pt, key = m_Key.publicKey[0], position;
	for (long long int x : m_originalMessageAscii)
	{
		pt = x - 32;
		position = 1;
		for (int y = 0; y < key; y++)
		{
			position *= pt;
			position %= m_n;
		}
		m_encryptedMessageAscii.push_back(position);
	}
	m_encryptedMessageAscii.push_back(0); // \0
	m_encryptedMessage = Utility::convertBytesToU32String(m_encryptedMessageAscii);

	//std::wstring_convert<std::codecvt_utf16<char32_t>,char32_t> convert32;

	//std::string converted = convert32.to_bytes(m_encryptedMessage);
	
	fmt::print("Encrypted Data: ");
	for (long long int x : m_encryptedMessageAscii)
	{
		fmt::print("{:X} ", x);
	}
	fmt::print("\n");
	fmt::print("Encrypted HASHDir: {}\n", Utility::hashish(m_encryptedMessage));
}

void RSA::Decrypt()
{
	if (!m_originalMessageAscii.empty())
	{
	m_originalMessageAscii.clear();
	}


	unsigned long long int key = m_Key.privateKey[0], position;
	int i = 0;
	for (long long int x : m_encryptedMessageAscii)
	{
		position = 1;
		for (int y = 0; y < key; y++)
		{
			position *= x;
			position %= m_n;
		}
		m_originalMessageAscii.push_back(position + 32);
		i++;
	}
	m_originalMessageAscii.push_back(0); // \0
	m_originalMessage = Utility::convertBytesToString(m_originalMessageAscii);
	

	fmt::print("Decrypted Data: {}", m_originalMessage);
}

void RSA::createEncryptedPackets()
{
	using u16ofstream = std::basic_ofstream<char32_t>;

	u16ofstream encryptedData('.'+ rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "enc.dat", std::ofstream::out | std::ofstream::app);

	
	if (encryptedData.is_open())
	{
	EncryptedFileDir = '.' + rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "enc.dat";
	encryptedData << m_encryptedMessage << std::endl;
	}
	else
	{
		fmt::print("Unable to open the file {0}\n", rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "enc.dat");
	}
	

	encryptedData.close();

	
	std::ofstream Keys('.' + rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "Keys.dat", std::ofstream::out | std::ofstream::app);

	if (Keys.is_open())
	{
		EncryptedKeyFileDir = '.' + rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "Keys.dat";
		for (auto x : m_Key.privateKey)
		{
			Keys << x << " ";
		}
	}
	else
	{
		fmt::print("Unable to open the file {0}\n", rootFolder + '/' + Utility::hashish(m_encryptedMessage) + '/' + "Keys.dat");
	}
}
