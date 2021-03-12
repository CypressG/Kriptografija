#include "AESDecryptorCustom.h"



AESDecryptorCustom::AESDecryptorCustom(std::string FileLoc, std::string key, CryptoPP::byte* iv)
{
	m_FileLoc = FileLoc;
	m_bytekey = (CryptoPP::byte*)key.c_str();
	m_iv = iv;
	aesDecryption = CryptoPP::AES::Decryption(m_bytekey, 32);

	CBCdecryption = CryptoPP::CBC_Mode_ExternalCipher::Decryption(aesDecryption, m_iv);
	ECBdecryption = CryptoPP::ECB_Mode_ExternalCipher::Decryption(aesDecryption, m_iv);
}

AESDecryptorCustom::~AESDecryptorCustom()
{

}

void AESDecryptorCustom::Decrypt(DMODESELECT mode)
{
	switch (mode)
	{
	case CBCDECRYPTION:
		try
		{
			CryptoPP::FileSource fsDecryptor(m_FileLoc.c_str(), true, new CryptoPP::StreamTransformationFilter(CBCdecryption,
				new CryptoPP::StringSink(m_DecryptedText)));
			break;
		}
		catch (CryptoPP::Exception)
		{

		}
	case ECBDECRYPTION:
		try
		{
			CryptoPP::FileSource fsDecryptor(m_FileLoc.c_str(), true, new CryptoPP::StreamTransformationFilter(ECBdecryption,
				new CryptoPP::StringSink(m_DecryptedText)));
			break;
		}
		catch (CryptoPP::Exception)
		{

		}
		

	}
}
