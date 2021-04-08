#pragma once

#include "Includes.h"

namespace Utility
{
	std::vector<long long int> convertStringToBytes(std::string targetString);
	std::vector<long long int> convertU16StringToBytes(std::u16string targetString);
	std::u16string convertBytesToU16String(std::vector<long long int> targetBytes);
	std::string convertBytesToString(std::vector<long long int> targetBytes);
	bool checkIfPrime(long long int x);
	long int cd(long long int a, long long int phi);
	std::string hashish(std::u16string encryptedMessage);
	void createDirectory(std::string rootdirname ,std::string dirname);
	std::u16string readEncryptedStringFile(std::string dir);
	std::vector<long long int> readEncryptedKeyFile(std::string dir);
}