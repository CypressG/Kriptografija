#pragma once

#include <iostream>
#include <iomanip>

#include "modes.h"
#include "aes.h"
#include "filters.h"
#include "files.h"

enum DMODESELECT
{
	CBCDECRYPTION = 0,
	ECBDECRYPTION = 1
};

class AESDecryptorCustom
{
public:
	AESDecryptorCustom(std::string FileLoc, std::string key, CryptoPP::byte* iv);
	~AESDecryptorCustom();

	void Decrypt(DMODESELECT mode);


	std::string getDecryptedText() const { return m_DecryptedText; }
	void getDecryptedText(std::string val) { m_DecryptedText = val; }

private:

	CryptoPP::AES::Decryption aesDecryption;
	CryptoPP::CBC_Mode_ExternalCipher::Decryption CBCdecryption;
	CryptoPP::ECB_Mode_ExternalCipher::Decryption ECBdecryption;

	CryptoPP::byte* m_bytekey;
	CryptoPP::byte* m_iv;
	std::string m_FileLoc;

	std::string m_DecryptedText;
};