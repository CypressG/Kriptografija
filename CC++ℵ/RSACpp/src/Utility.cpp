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

std::string Utility::convertBytesToString(std::vector<long long int> targetBytes)
{
	std::string temp;
	temp.reserve(targetBytes.size());
	for (long long int x : targetBytes)
	{
		temp.push_back(static_cast<char>(x));
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
