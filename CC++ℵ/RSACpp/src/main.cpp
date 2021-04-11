#define  UNICODE
#include <windows.h>
#include <fcntl.h>
#include <io.h>
#include <cstdio>
#include "Includes.h"
#include "RSA.h"

int main()
{
	//std::locale::global(std::locale("en_US.UTF-8"));
	RSA a = RSA();

	std::u32string encryptedText = Utility::readEncryptedStringFile(a.GetEncryptedFileDir());
	std::vector<long long int> Keys = Utility::readEncryptedKeyFile(a.GetEncryptedKeyFileDir());

	//int x = 5;
	RSA b = RSA(encryptedText, a.get_n(), Keys);

	return 0;
}