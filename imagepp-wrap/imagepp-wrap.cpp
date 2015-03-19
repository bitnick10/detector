// imagepp-wrap.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <cstdint>
#include <Image.h>
using namespace imagepp;
void* ImageRGBByte_LoadFromFile(const char* filename) {
    Image<RGB<unsigned char>>* image = new Image<RGB<unsigned char>>(filename);
    return image;
}
unsigned int ImageRGBByte_Height(void* image) {
    return ((Image<RGB<unsigned char>>*)image)->height();
}
unsigned int ImageRGBByte_Width(void* image) {
    return ((Image<RGB<unsigned char>>*)image)->width();
}
void* ImageRGBByte_DataPtr(void* image) {
    return ((Image<RGB<unsigned char>>*)image)->data();
}
int ImageRGBByte_GetPixel(void* image, unsigned int x, unsigned int y) {
    ARGB<unsigned char> ret;
    RGB<unsigned char> c = ((Image<RGB<unsigned char>>*)image)->GetPixel(x, y);
    ret.a = 255;
    ret.r = c.r;
    ret.g = c.g;
    ret.b = c.b;

    ret.a = c.b;
    ret.r = c.g;
    ret.g = c.r;
    ret.b = 255;

    return *((int*)&ret);
}
int add(int x, int y) {
    return x + y;
}
int sub(int x, int y) {
    return x - y;
}