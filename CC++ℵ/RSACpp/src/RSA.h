#pragma once
#include "Includes.h"

class RSA
{
public: 
	RSA(); //Encryption constructor
	RSA(std::string encryptedMessage, std::vector<long int> publicKey); //Decryption constructor
	~RSA();

private:
	std::string m_originalMessage = nullptr; //Original or Decrypted
	std::string m_encryptedMessage = nullptr; //Encrypted
	std::vector<long long int> m_originalMessageAscii; //Original or Decrypted
	std::vector<long long int> m_encryptedMessageAscii; //Encrypted
	long long int m_p = 0;
	long long int m_q = 0;
	
};