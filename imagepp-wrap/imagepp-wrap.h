#pragma once
extern "C"  {
    _declspec(dllexport) void* ImageRGBByte_LoadFromFile(const char* filename);
    _declspec(dllexport) unsigned int ImageRGBByte_Height(void* image);
    _declspec(dllexport) unsigned int ImageRGBByte_Width(void* image);
    _declspec(dllexport) void* ImageRGBByte_DataPtr(void* image);
    _declspec(dllexport) int ImageRGBByte_GetPixel(void* image, unsigned int x, unsigned int y);
}
extern "C"  {
    _declspec(dllexport) int add(int x, int y);
    _declspec(dllexport) int sub(int x, int y);
}
