#include "Caesar.hpp"


CaesarEncrypt::CaesarEncrypt(std::wstring message, uint32_t rot)
{
	for (char16_t character : message)
	{
		uint32_t numericvalue = static_cast<uint32_t>(character) + rot;
		EncryptedString.push_back(static_cast<wchar_t>(numericvalue));
	}

}

CaesarDecrypt::CaesarDecrypt(std::wstring message, uint32_t rot)
{
	for (char16_t character : message)
	{
		uint32_t numericvalue = static_cast<uint32_t>(character) - rot;
		DecryptedString.push_back(static_cast<wchar_t>(numericvalue));
	}
}