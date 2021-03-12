#pragma once
#include <cstdio>
#define FMT_HEADER_ONLY
#include <fmt/format.h>

namespace FileManUtils
{
	const char* readFileplain(const char* filepath, size_t& SofA);
	const char* readFilebinary(const char* filepath, size_t& SofA);
	void writeToFile(const char* filepath, std::string data);
}