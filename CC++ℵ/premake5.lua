workspace "Kriptografija"
architecture "x86_64"
startproject "CeaserCypherC++"

configurations { "Debug", "Release" }
    
    flags
	{
		"MultiProcessorCompile"
    }
    
    outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

    IncludeDir = {}
    IncludeDir["fmt"] = "Vendor/fmt/include"
    IncludeDir["cryptopp"] = "Vendor/cryptopp"

    project "CeaserCypherC++"
            location "CeaserCypherCPP"
            kind "ConsoleApp"
            language "C++"
            cppdialect "C++17"
            staticruntime "on"

            targetdir ("bin/" .. outputdir .. "/%{prj.name}")
            objdir("bin-int/" .. outputdir .. "/%{prj.name}")

            files
            {
                "%{prj.name}/src/*.h",
                "%{prj.name}/src/*.hpp",
                "%{prj.name}/src/*.cpp",
            }

            defines
            {
                "_CRT_SECURE_NO_WARNINGS",
            }

            includedirs
            {
                "%{prj.name}/src/*",
                "%{IncludeDir.fmt}"             
            }

            filter "configurations:Debug"
                    defines { "DEBUG" }
                    runtime "Debug"
                    symbols "On"
              
                 filter "configurations:Release"
                    defines { "NDEBUG" }
                    runtime "Release"
                    optimize "On"

    project "AESCpp"
            location "AESCpp"
            kind "ConsoleApp"
            language "C++"
            cppdialect "C++17"
            staticruntime "on"

            targetdir ("bin/" .. outputdir .. "/%{prj.name}")
            objdir("bin-int/" .. outputdir .. "/%{prj.name}")

            files
            {
                "%{prj.name}/src/*.h",
                "%{prj.name}/src/*.hpp",
                "%{prj.name}/src/*.cpp",
            }

            defines
            {
                "_CRT_SECURE_NO_WARNINGS",
            }

            includedirs
            {
                "%{prj.name}/src/*",
                "%{IncludeDir.fmt}",
                "%{IncludeDir.cryptopp}"             
            }

            filter "configurations:Debug"
                    defines { "DEBUG" }
                    runtime "Debug"
                    symbols "On"
                    libdirs
                    {
                        "%{IncludeDir.cryptopp}/x64/Output/Debug"
                    }
        
                    links
                    {
                        "cryptlib"
                    }
              
                 filter "configurations:Release"
                    defines { "NDEBUG" }
                    runtime "Release"
                    optimize "On"
                    libdirs
                    {
                        "%{IncludeDir.cryptopp}/x64/Output/Release"
                    }
        
                    links
                    {
                        "cryptlib"
                    }
