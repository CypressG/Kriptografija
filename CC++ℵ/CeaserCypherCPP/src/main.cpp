#include "Caesar.hpp"


int main()
{

	CaesarEncrypt encrypt = CaesarEncrypt("Devlačąb123", 20);
	std::cout << encrypt.showMessage() << std::endl;
	CaesarDecrypt decrypt = CaesarDecrypt(encrypt.showMessage(), 20);
	std::cout << decrypt.showMessage() << std::endl;
	return 0;
}