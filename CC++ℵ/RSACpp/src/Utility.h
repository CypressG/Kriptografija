#pragma once

#include "Includes.h"

namespace Utility
{
	std::vector<long long int> convertStringToBytes(std::string targetString);
	std::vector<long long int> convertU32StringToBytes(std::u32string targetString);
	std::u32string convertBytesToU32String(std::vector<long long int> targetBytes);
	std::string convertBytesToString(std::vector<long long int> targetBytes);
	bool checkIfPrime(long long int x);
	long int gcd(int a, int b);
	long int cd(long long int a, long long int phi);
	std::string hashish(std::u32string encryptedMessage);
	void createDirectory(std::string rootdirname ,std::string dirname);
	std::u32string readEncryptedStringFile(std::string dir);
	std::vector<long long int> readEncryptedKeyFile(std::string dir);
}