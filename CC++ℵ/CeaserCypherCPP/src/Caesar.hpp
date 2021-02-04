#include <iostream>
#include <algorithm>


class CaesarEncrypt
{
public:
	CaesarEncrypt(std::wstring message, uint32_t rot);

	inline std::wstring showMessage() { return EncryptedString; }
private:
	std::wstring EncryptedString;

};

class CaesarDecrypt
{
public:
	CaesarDecrypt(std::wstring message, uint32_t rot);

	inline std::wstring showMessage() { return DecryptedString; }
private:
	std::wstring DecryptedString;
};