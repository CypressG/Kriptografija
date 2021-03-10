#include "Caesar.hpp"
#include <fstream>
#define FMT_HEADER_ONLY
#include <fmt/format.h>


int main()
{

	std::wstring input;
	uint32_t rot = 0;
	fmt::print("Iveskite norima zinute: ");
	scanf("%s", &input);
	getchar();
	fmt::print("Iveskite norima poslinki: ");
	scanf("%d", &rot);
	getchar();

	CaesarEncrypt encrypt = CaesarEncrypt(input, rot);
	fmt::print(L"Encrypted result: {0} \n", encrypt.showMessage());

	CaesarDecrypt decrypt = CaesarDecrypt(encrypt.showMessage(), rot);
	fmt::print(L"Decrypted result: {0} \n", decrypt.showMessage());

	return 0;
}