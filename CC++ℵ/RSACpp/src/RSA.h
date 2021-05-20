#pragma once
#include "Includes.h"
#include "Utility.h"


struct Key
{
	std::vector<long long int> privateKey;
	std::vector<long long int> publicKey;
};

class RSA
{
public: 
	RSA(); //Encryption constructor
	RSA(std::u32string encryptedMessage, long long int n, std::vector<long long int> publicKey); //Decryption constructor
	~RSA();

private:
	std::string m_originalMessage; //Original or Decrypted
	std::u32string m_encryptedMessage; //Encrypted
	std::vector<long long int> m_originalMessageAscii; //Original or Decrypted
	std::vector<long long int> m_encryptedMessageAscii; //Encrypted
	long long int m_p = 0;
	long long int m_q = 0;
	long long int m_n = 0; // m_p * m_q
	long long int m_phi = 0; // (m_p - 1) * (m_q -1)
	std::vector<long long int> m_positions;
	Key m_Key;

	void generateKeys();
	void Encrypt();
	void Decrypt();
	void createEncryptedPackets();

	std::string rootFolder = "./EncryptedOnes";
	std::string EncryptedFileDir = " ";
	std::string EncryptedKeyFileDir = " ";
	
public:
	long long int get_n() const { return m_n; }
	std::string GetEncryptedFileDir() const { return EncryptedFileDir; }
	std::string GetEncryptedKeyFileDir() const { return EncryptedKeyFileDir; }
};