#include "Caesar.hpp"


CaesarEncrypt::CaesarEncrypt(std::string message, uint32_t rot)
{
	for (char character : message)
	{
		uint32_t numericvalue = static_cast<uint32_t>(character) + rot;
		EncryptedString.push_back(static_cast<char>(numericvalue));
	}

}

CaesarDecrypt::CaesarDecrypt(std::string message, uint32_t rot)
{
	for (char character : message)
	{
		uint32_t numericvalue = static_cast<uint32_t>(character) - rot;
		DecryptedString.push_back(static_cast<char>(numericvalue));
	}
}
