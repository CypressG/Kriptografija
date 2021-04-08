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

std::vector<long long int> Utility::convertU16StringToBytes(std::u16string targetString)
{
	std::vector<long long int> temp;
	temp.reserve(targetString.size());
	for (char16_t x : targetString)
	{
		temp.push_back(static_cast<long long int>(x));
	}
	return temp;
}

std::u16string Utility::convertBytesToU16String(std::vector<long long int> targetBytes)
{
	std::u16string temp;
	temp.reserve(targetBytes.size());
	for (long long int x : targetBytes)
	{
		temp.push_back(static_cast<char16_t>(x));
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

long int Utility::cd(long long int a, long long int phi)
{
	long int k = 1;
	while (true)
	{
	k = k + phi;
	if (k % a == 0)
	return(k / a);
	}
}

std::string Utility::hashish(std::u16string encryptedMessage)
{
	std::hash<std::u16string> hashStr;
	size_t hash = hashStr(encryptedMessage);
	return std::to_string(hash);
}

void Utility::createDirectory(std::string rootdirname, std::string dirname)
{
	std::filesystem::current_path(rootdirname);
	std::filesystem::create_directory(dirname);
}

std::u16string Utility::readEncryptedStringFile(std::string dir)
{
	std::u16string temp;
	using u16ifstream = std::basic_ifstream<char16_t>;

	u16ifstream file(dir, std::ifstream::out | std::ifstream::app);

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
