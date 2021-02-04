#include "Caesar.hpp"
#include <fstream>
#define FMT_HEADER_ONLY
#include <fmt/format.h>


int main()
{

	std::wstring input;
	uint32_t rot;
	fmt::print("Iveskite norima zinute: ");
	std::wcin >> input;
	fmt::print("Iveskite norima poslinki: ");
	std::wcin >> rot;


	CaesarEncrypt encrypt = CaesarEncrypt(input,rot);
	fmt::print(L"Encrypted result: {0} \n", encrypt.showMessage());

	CaesarDecrypt decrypt = CaesarDecrypt(encrypt.showMessage(), rot);
	fmt::print(L"Decrypted result: {0} \n", decrypt.showMessage());

	return 0;
}