#include <iostream>
#include <algorithm>
#include <utility>
#include <memory_resource>
#include <string>
#include <sstream>


class CaesarEncrypt
{
public:
	CaesarEncrypt(std::string message, uint32_t rot);

	inline std::string showMessage() { return EncryptedString; }
private:
	std::string EncryptedString;

};

class CaesarDecrypt
{
public:
	CaesarDecrypt(std::string message, uint32_t rot);

	inline std::string showMessage() { return DecryptedString; }
private:
	std::string DecryptedString;
};