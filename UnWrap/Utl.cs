﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnWrap
{
    class Utl
    {
        private static int FindOccure(string str, string find, int num)
        {
            //функция ищет позицию num вхождения строки find в строку str
            int cnt = 1;
            int pos = str.IndexOf(find, 0);
            while ((pos == -1) || (cnt < num))
            {
                cnt++;
                pos = str.IndexOf(find, pos + find.Length);
            }

            return pos;
        }

        private static byte[] Trans(byte[] v_inp)
        {
            //перевод из одних байтов в другие

            //таблица перевода
            byte[] inTrans = {
                 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F,
                 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
                 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7E, 0x7F,
                 0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F,
                 0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x9D, 0x9E, 0x9F,
                 0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7, 0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE, 0xAF,
                 0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7, 0xB8, 0xB9, 0xBA, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF,
                 0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7, 0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xCF,
                 0xD0, 0xD1, 0xD2, 0xD3, 0xD4, 0xD5, 0xD6, 0xD7, 0xD8, 0xD9, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE, 0xDF,
                 0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5, 0xE6, 0xE7, 0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xEE, 0xEF,
                 0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, 0xF6, 0xF7, 0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF
            };

            byte[] outTrans = {
                 0x3D, 0x65, 0x85, 0xB3, 0x18, 0xDB, 0xE2, 0x87, 0xF1, 0x52, 0xAB, 0x63, 0x4B, 0xB5, 0xA0, 0x5F,
                 0x7D, 0x68, 0x7B, 0x9B, 0x24, 0xC2, 0x28, 0x67, 0x8A, 0xDE, 0xA4, 0x26, 0x1E, 0x03, 0xEB, 0x17,
                 0x6F, 0x34, 0x3E, 0x7A, 0x3F, 0xD2, 0xA9, 0x6A, 0x0F, 0xE9, 0x35, 0x56, 0x1F, 0xB1, 0x4D, 0x10,
                 0x78, 0xD9, 0x75, 0xF6, 0xBC, 0x41, 0x04, 0x81, 0x61, 0x06, 0xF9, 0xAD, 0xD6, 0xD5, 0x29, 0x7E,
                 0x86, 0x9E, 0x79, 0xE5, 0x05, 0xBA, 0x84, 0xCC, 0x6E, 0x27, 0x8E, 0xB0, 0x5D, 0xA8, 0xF3, 0x9F,
                 0xD0, 0xA2, 0x71, 0xB8, 0x58, 0xDD, 0x2C, 0x38, 0x99, 0x4C, 0x48, 0x07, 0x55, 0xE4, 0x53, 0x8C,
                 0x46, 0xB6, 0x2D, 0xA5, 0xAF, 0x32, 0x22, 0x40, 0xDC, 0x50, 0xC3, 0xA1, 0x25, 0x8B, 0x9C, 0x16,
                 0x60, 0x5C, 0xCF, 0xFD, 0x0C, 0x98, 0x1C, 0xD4, 0x37, 0x6D, 0x3C, 0x3A, 0x30, 0xE8, 0x6C, 0x31,
                 0x47, 0xF5, 0x33, 0xDA, 0x43, 0xC8, 0xE3, 0x5E, 0x19, 0x94, 0xEC, 0xE6, 0xA3, 0x95, 0x14, 0xE0,
                 0x9D, 0x64, 0xFA, 0x59, 0x15, 0xC5, 0x2F, 0xCA, 0xBB, 0x0B, 0xDF, 0xF2, 0x97, 0xBF, 0x0A, 0x76,
                 0xB4, 0x49, 0x44, 0x5A, 0x1D, 0xF0, 0x00, 0x96, 0x21, 0x80, 0x7F, 0x1A, 0x82, 0x39, 0x4F, 0xC1,
                 0xA7, 0xD7, 0x0D, 0xD1, 0xD8, 0xFF, 0x13, 0x93, 0x70, 0xEE, 0x5B, 0xEF, 0xBE, 0x09, 0xB9, 0x77,
                 0x72, 0xE7, 0xB2, 0x54, 0xB7, 0x2A, 0xC7, 0x73, 0x90, 0x66, 0x20, 0x0E, 0x51, 0xED, 0xF8, 0x7C,
                 0x8F, 0x2E, 0xF4, 0x12, 0xC6, 0x2B, 0x83, 0xCD, 0xAC, 0xCB, 0x3B, 0xC4, 0x4E, 0xC0, 0x69, 0x36,
                 0x62, 0x02, 0xAE, 0x88, 0xFC, 0xAA, 0x42, 0x08, 0xA6, 0x45, 0x57, 0xD3, 0x9A, 0xBD, 0xE1, 0x23,
                 0x8D, 0x92, 0x4A, 0x11, 0x89, 0x74, 0x6B, 0x91, 0xFB, 0xFE, 0xC9, 0x01, 0xEA, 0x1B, 0xF7, 0xCE
            };

            //переводим
            List<byte> res = new List<byte>();
            for (int i = 0; i < v_inp.Length; i++)
            {
                byte currByte = v_inp[i];
                int j = 0;
                for (j = 0; j < inTrans.Length; j++)
                {
                    if (currByte == inTrans[j])
                    {
                        break;
                    }
                }
                res.Add(outTrans[j]);
            }

            //возвращаем массив байт
            return res.ToArray();
        }

        private static T[] Crop<T>(T[] array, int startPos, int finishPos = -1)
        {
            //функция вырезает часть массива 
            List<T> arr = new List<T>();

            if (finishPos == -1)
            {
                finishPos = array.Length;
            }
            for (int i = startPos; i < finishPos; i++)
            {
                arr.Add(array[i]);
            }
            return arr.ToArray();
        }

        private static byte[] Subst(string v_inp)
        {
            //необходимо из исходного текста извлечь кусок в base64 (после 20 перевода строк)
            string inp = v_inp.Substring(FindOccure(v_inp, ((char)10).ToString(), 20) + 1);
            //заменим имеющиеся \r\n на пустоту
            inp = inp.Replace("\r", "").Replace("\n", "");

            //воспользуемся своим декодером
            Base64Decoder bd = new Base64Decoder(inp.ToCharArray());
            //декодируем из Base64 в массив байт и выдернем все значения с 20 элемента
            return Crop(bd.GetDecoded(), 20);
        }

        public static string text_source(string p_text)
        {
            byte[] v_x;            
            if (p_text.Substring(0, 6).ToUpper() != "CREATE")
            {
                v_x = Subst("CREATE " + p_text);
            }
            else
            {
                v_x = Subst(p_text);
            }
            //переведём полученный массив в соответствии с таблицей
            byte[] v_t = Trans(v_x);
            //преобразуем полученный массив байт в символы
            return Compress.Decompress(v_t);
        }
    }
}