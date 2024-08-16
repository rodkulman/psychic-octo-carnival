#include "pch.h"
#include "DataTypes.h"

#define DllExport extern "C" __declspec(dllexport)

using namespace Library;

DllExport int APIENTRY Add(int a, int b)
{
	return CSLibrary::Add(a, b);
}

DllExport int APIENTRY GetTextOKLength()
{
	array<wchar_t>^ str = CSLibrary::SayOK()->ToCharArray();

	return str->Length;
}

DllExport int APIENTRY GetTextOK(LPWSTR text, int count)
{
	array<wchar_t>^ str = CSLibrary::SayOK()->ToCharArray();
	int length = str->Length;

	if (count < length) 
	{
		length = count;
	}

	for (int i = 0; i < length; i++)
	{
		text[i] = str[i];
	}

	return length;
}

DllExport int APIENTRY GetRandomsLength(int seed)
{
	array<int>^ randoms = CSLibrary::GetRandoms(seed);

	return randoms->Length;
}

DllExport int APIENTRY GetRandoms(int* data, int count, int seed)
{
	array<int>^ randoms = CSLibrary::GetRandoms(seed);
	int length = randoms->Length;

	if (count < length)
	{
		length = count;
	}

	for (int i = 0; i < length; i++)
	{
		data[i] = randoms[i];
	}

	return length;
}

DllExport int APIENTRY GetImportantInfo(__ImportantInfo* _info)
{
	ImportantInfo^ info = CSLibrary::GetImportantInfo();

	_info->Age = info->Age;

	_info->Date.wYear = info->Date.Year;
	_info->Date.wMonth = info->Date.Month;
	_info->Date.wDay = info->Date.Day;
	_info->Date.wDayOfWeek = (int)info->Date.DayOfWeek;
	_info->Date.wHour = (int)info->Date.Hour;
	_info->Date.wMinute = (int)info->Date.Minute;
	_info->Date.wSecond = (int)info->Date.Second;
	_info->Date.wMilliseconds = (int)info->Date.Millisecond;

	array<wchar_t>^ str = info->Name->ToCharArray();
	int length = str->Length;

	if (_info->NameLength < length)
	{
		length = _info->NameLength;
	}

	for (int i = 0; i < length; i++)
	{
		_info->Name[i] = str[i];
	}

	_info->NameLength = str->Length;

	return S_OK;
}