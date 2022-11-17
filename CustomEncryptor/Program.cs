using CustomEncryptor;

string value = "Today is a beatiful day";
//string value = "";
//Console.Write($"Enter a plaintext : {value}");
//Console.ReadLine();



var e1 = PassEncryptor.NextLetterEnc(value, 10);
var e2 = PassEncryptor.NextLetterDec(e1);
var e3 = PassEncryptor.ByteBaseEnc(value);
var e4 = PassEncryptor.ByteBaseDec(e3);
var e5 = PassEncryptor.RandomByteBaseEnc(value, "this is a key");
var e6 = PassEncryptor.MD5_Enc(value);
var e7 = PassEncryptor.SHA256_Enc(value);
var e8 = PassEncryptor.SHA512_Enc(value);

Console.WriteLine($"Encrypted: {e1}");
Console.WriteLine($"Decrypted: {e2}");
Console.WriteLine($"-- Encrypted Byte of Password: {e3}");
Console.WriteLine($"Decrypted Byte of Password: {e4}");
Console.WriteLine($"Encrypted Byte of Password: {e5}");
Console.WriteLine($"MD5 : {e6}");
Console.WriteLine($"SHA256 : {e7}");
Console.WriteLine($"SHA512 : {e8}");

Console.ReadLine();