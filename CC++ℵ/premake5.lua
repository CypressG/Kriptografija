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
                "%{prj.name}/src/**",
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