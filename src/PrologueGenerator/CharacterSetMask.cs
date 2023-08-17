public enum CharacterSetMask
{
    Capital = 0x01,
    Lowercase = 0x02,
    Digits = 0x04,
    Symbols = 0x08,
    ExcludeAmbiguous = 0x10,
    All = Capital | Lowercase | Digits | Symbols | ExcludeAmbiguous,
}
