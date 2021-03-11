#pragma once

#include <iostream>
#include <iomanip>

#include "modes.h"
#include "aes.h"
#include "filters.h"
#include "files.h"

enum MODESELECT
{
	CBCENCRYPTION = 0,
	ECBENCRYPTION = 1
};

class AESEncryptor
{
public:
	AESEncryptor(std::string m_message, std::string key, CryptoPP::byte* iv);
	~AESEncryptor();

	void Encrypt(MODESELECT mod, std::string filename);

private:
	CryptoPP::AES::Encryption aesEncryption;
	CryptoPP::CBC_Mode_ExternalCipher::Encryption CBCencryption;
	CryptoPP::ECB_Mode_ExternalCipher::Encryption ECBencryption;

	CryptoPP::byte* m_bytekey;
	CryptoPP::byte* m_iv;
	std::string m_message;

};

