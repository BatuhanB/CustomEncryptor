using CustomEncryptor;

string value = "Batuhan";

PassEncryptor passEncryptor = new();

var e1 = passEncryptor.NextLetterEnc(value, 10);
var e2 = passEncryptor.NextLetterDec(e1);
var e3 = passEncryptor.ByteBaseEnc(value);
var e4 = passEncryptor.ByteBaseDesc(e3);
var e5 = passEncryptor.RandomByteBaseEnc(value, "this is a key");
var e6 = passEncryptor.MD5_Enc(value);
var e7 = passEncryptor.SHA256_Enc(value);

Console.WriteLine($"Encrypted: {e1}");
Console.WriteLine($"Decrypted: {e2}");
Console.WriteLine($"Encrypted Byte of Password: {e3}");
Console.WriteLine($"Decrypted Byte of Password: {e4}");
Console.WriteLine($"Encrypted Byte of Password: {e5}");
Console.WriteLine($"MD5 : {e6}");
Console.WriteLine($"SHA256 : {e7}");

Console.ReadLine();