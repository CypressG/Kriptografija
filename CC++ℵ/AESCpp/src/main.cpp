#include <iostream>
#include <iomanip>

#include "modes.h"
#include "files.h"
#include "aes.h"
#include "filters.h"
#include "randpool.h"
#include "padlkrng.h"

#include "FileManUtils.h"
#include "AESEncryptor.h"
#include "AESDecryptorCustom.h"

int main(int argc, char* argv[])
{
	std::string rootDir = "../AESCpp/src/";
	std::string key;
	std::string message;
	std::string encrypted_filename;
	int modeSel = -1;

	CryptoPP::byte iv[CryptoPP::AES::BLOCKSIZE];
	CryptoPP::RandomPool rnd;
	memset(iv, 0x00, CryptoPP::AES::BLOCKSIZE);
	rnd.GenerateBlock(iv, CryptoPP::AES::BLOCKSIZE);
	/**
	FileManUtils::writeToFile("ivCode.bin", (char*)iv);
	
	std::cout << "input message to encrypt please" << std::endl;
	std::getline(std::cin, message);
	std::cout << "input encryption key please" << std::endl;
	std::getline(std::cin, key);

	AESEncryptor test = AESEncryptor(message, key, iv);

	std::cout << "input filename in which encrypted message is going to be held" << std::endl;
	std::getline(std::cin, encrypted_filename);

	std::cout << "input mode with which is it going to be encrypted" << std::endl;

	std::cout << "0- CBC\n1-ECB" << std::endl;
	while (1)
	{
		std::cin >> modeSel;
		if (modeSel != 0 && modeSel != 1)
		{
			std::cout << "Incorrect input" << std::endl;
		}
		else
		{
			break;
		}
	}
	std::cin.ignore();

	test.Encrypt(static_cast<MODESELECT>(modeSel), encrypted_filename);


	std::cout << "ENCRYPTION ENDS:" << std::endl;

	std::cout << "input decryption key please" << std::endl;
	std::getline(std::cin, key);

	std::cout << "input filename in which encrypted message is held" << std::endl;
	std::getline(std::cin, encrypted_filename);
	size_t size;
	*/
	AESDecryptorCustom test1 = AESDecryptorCustom(rootDir + encrypted_filename, key, (CryptoPP::byte*)FileManUtils::readFilebinary("ivCode.bin", size));

	std::cout << "input mode with which is it going to be decrypted" << std::endl;
	std::cout << "0-CBC\n1-ECB" << std::endl;
	modeSel = -1;
	while (1)
	{
		std::cin >> modeSel;
		if (modeSel != 0 && modeSel != 1)
		{
			std::cout << "Incorrect input" << std::endl;
		}
		else
		{
			break;
		}
	}

	test1.Decrypt(static_cast<DMODESELECT>(modeSel));

	std::cout << "Decrypted text: " << test1.getDecryptedText() << std::endl;

	return 0;
}