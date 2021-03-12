#include "AESEncryptor.h"



AESEncryptor::AESEncryptor(std::string message , std::string key, CryptoPP::byte* iv)
{
	m_message = message;
	m_bytekey = (CryptoPP::byte*)key.c_str();
	m_iv = iv;
	aesEncryption = CryptoPP::AES::Encryption(m_bytekey,32);

	CBCencryption = CryptoPP::CBC_Mode_ExternalCipher::Encryption(aesEncryption, m_iv);
	ECBencryption = CryptoPP::ECB_Mode_ExternalCipher::Encryption(aesEncryption, m_iv);
}

AESEncryptor::~AESEncryptor()
{

}

void AESEncryptor::Encrypt(MODESELECT mod,std::string filename)
{
	std::string rootdir = "../AESCpp/src/";
	switch (mod)
	{
	case CBCENCRYPTION:
		try
		{
			CryptoPP::StringSource fsDecryptor(m_message, true, new CryptoPP::StreamTransformationFilter(CBCencryption,
				new CryptoPP::FileSink((rootdir+filename).c_str())));
			break;
			
		}
		catch(CryptoPP::Exception)
		{
			std::cout << "Unexpected encryption error!" << std::endl;
		}
	case ECBENCRYPTION:
		try
		{
			CryptoPP::StringSource fsDecryptor(m_message, true, new CryptoPP::StreamTransformationFilter(ECBencryption,
				new CryptoPP::FileSink((rootdir+filename).c_str())));
		}
		catch (CryptoPP::Exception e)
		{
			std::cout << "Unexpected encryption error!" << std::endl;
		}

	}

}
