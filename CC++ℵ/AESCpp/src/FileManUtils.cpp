#include "FileManUtils.h"

const char* FileManUtils::readFilebinary(const char* filepath, size_t& length)
{

	FILE* fp = fopen(filepath, "rb");
	if (fp == NULL)
	{
		fmt::print("Cannot open file %s", filepath);
	}
	fseek(fp, 0, SEEK_END);
	length = ftell(fp);
	char* promisedString = (char*)malloc(length);
	fseek(fp, 0, SEEK_SET);
	fread(promisedString, sizeof(char), length, fp);
	fclose(fp);



	return promisedString;
}

const char* FileManUtils::readFileplain(const char* filepath, size_t& length)
{

	FILE* fp = fopen(filepath, "rb");
	if (fp == NULL)
	{
		fmt::print("Cannot open file %s", filepath);
	}
	fseek(fp, 0, SEEK_END);
	length = ftell(fp);
	char* promisedString = (char*)calloc(length + 1 , 1);
	fseek(fp, 0, SEEK_SET);
	fread(promisedString, 1, length, fp);
	fclose(fp);



	return promisedString;
}


void FileManUtils::writeToFile(const char* filepath, std::string data)
{
	FILE* fp = fopen(filepath, "wb");
	if (fp == NULL)
	{
		fmt::print("Cannot open file %s", filepath);
	}
	fwrite(reinterpret_cast<const unsigned char*>(data.c_str()), sizeof(char), data.size(), fp);
	fclose(fp);
}

