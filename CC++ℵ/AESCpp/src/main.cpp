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

	CryptoPP::byte iv[CryptoPP::AES::BLOCKSIZE];
	CryptoPP::RandomPool rnd;
	memset(iv, 0x00, CryptoPP::AES::BLOCKSIZE);
	rnd.GenerateBlock(iv, CryptoPP::AES::BLOCKSIZE);

	std::cout << "input message to encrypt please" << std::endl;
	std::string message;
	std::getline(std::cin, message);
	std::cout << "input encryption key please" << std::endl;
	std::string key;
	std::getline(std::cin, key);
	
	AESEncryptor test = AESEncryptor(message, key, iv);

	std::cout << "input filename in which encrypted message is going to be held" << std::endl;
	std::string encrypted_filename;
	std::getline(std::cin, encrypted_filename);
	test.Encrypt(CBCENCRYPTION,encrypted_filename);


	std::cout << "ENCRYPTION ENDS:"  << std::endl;

	std::cout << "input decryption key please" << std::endl;
	std::getline(std::cin, key);

	std::cout << "input filename in which encrypted message is held" << std::endl;
	std::getline(std::cin, encrypted_filename);

	
	AESDecryptorCustom test1 = AESDecryptorCustom(rootDir+encrypted_filename, key, iv);
	test1.Decrypt(CBCDECRYPTION);

	std::cout << test1.getDecryptedText() << std::endl;

	return 0;
}