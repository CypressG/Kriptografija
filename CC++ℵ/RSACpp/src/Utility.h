#pragma once

#include "Includes.h"

namespace Utility
{
	std::vector<long long int> convertStringToBytes(std::string targetString);
	std::string convertBytesToString(std::vector<long long int> targetBytes);
	bool checkIfPrime(long long int x);

}