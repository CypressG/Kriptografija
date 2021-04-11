#include "Utility.h"



std::vector<long long int> Utility::convertStringToBytes(std::string targetString)
{
	std::vector<long long int> temp;
	temp.reserve(targetString.size());
	for (char x : targetString)
	{
		temp.push_back(static_cast<long long int>(x));
	}
	return temp;
}

std::vector<long long int> Utility::convertU32StringToBytes(std::u32string targetString)
{
	std::vector<long long int> temp;
	temp.reserve(targetString.size());
	for (char32_t x : targetString)
	{
		temp.push_back(static_cast<long long int>(x));
	}
	return temp;
}

std::u32string Utility::convertBytesToU32String(std::vector<long long int> targetBytes)
{
	std::u32string temp;
	temp.reserve(targetBytes.size());
	for (long long int x : targetBytes)
	{
		temp.push_back(static_cast<char32_t>(x));
	}

	return temp;
}

std::string Utility::convertBytesToString(std::vector<long long int> targetBytes)
{
	std::string temp;
	temp.reserve(targetBytes.size());
	for (long long int x : targetBytes)
	{
		temp.push_back((char)x);
	}

	return temp;
}

bool Utility::checkIfPrime(long long int x)
{
	if (x <= 1)
		return false;

	for (int i = 2; i < x; i++)
		if (x % i == 0)
			return false;

	return true;
}

long int Utility::gcd(int a, int b)
{
	if (a == 0)
		return b;
	return gcd(b % a, a);
}

long int Utility::cd(long long int a, long long int phi)
{
	long long int k = 1;
	while (true)
	{
		k += phi;
		if (k % a == 0)
			return(k / a);
	}
}

std::string Utility::hashish(std::u32string encryptedMessage)
{
	int x = 5;
	std::hash<std::u32string> hashStr;
	long long unsigned int hash = hashStr(encryptedMessage);
	return std::to_string(hash);
}

void Utility::createDirectory(std::string rootdirname, std::string dirname)
{
	std::filesystem::current_path(rootdirname);
	std::filesystem::create_directory(dirname);
}

std::u32string Utility::readEncryptedStringFile(std::string dir)
{
	std::u32string temp;
	using u32ifstream = std::basic_ifstream<char32_t>;

	u32ifstream file(dir, std::ifstream::out | std::ifstream::app);

	if (file.is_open())
	{
		file >> temp;
	}
	else
	{
		fmt::print("Fatal error while reading encrypted string!");
	}
	file.close();
	return temp;
}

std::vector<long long int> Utility::readEncryptedKeyFile(std::string dir)
{
	std::vector<long long int> temp;
	std::ifstream file(dir, std::ifstream::out | std::ifstream::app);

	if (file.is_open())
	{
		int currentNumber = 0;
		while (file >> currentNumber)
		{
			temp.emplace_back(currentNumber);
		}
	}
	else
	{
		fmt::print("Fatal error while reading encrypted string!");
	}
	file.close();

	return temp;
}
