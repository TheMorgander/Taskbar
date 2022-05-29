@echo off

SET path_dll=Taskbar.dll
SET path_ohm=LibreHardwareMonitorLib.dll
SET path_hs=HidSharp.dll
SET path_regasm=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe

net session >nul 2>&1
if NOT %errorLevel% == 0 (
	echo Please start as administrator.
	pause >nul
	exit
)

cd %~dp0\..\bin\Debug

"%path_regasm%" /u %path_dll%
"%path_regasm%" /u %path_ohm%
"%path_regasm%" /u %path_hs%

taskkill.exe /im explorer.exe /f
explorer