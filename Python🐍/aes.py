import hashlib
from Crypto import Random
from Crypto.Cipher import AES
from base64 import b64encode, b64decode

class AESCipher(object):
    def __init__(self, raktas):
        self.bloko_dydis = AES.block_size
        self.raktas = hashlib.sha256(raktas.encode()).digest()

    def encrypt(self, paprastas_tekstas):
        plain_text = self.__pad(paprastas_tekstas)
        iv = Random.new().read(self.bloko_dydis)
        sifras = AES.new(self.raktas, AES.MODE_CBC, iv)
        sifruotas_tekstas = sifras.encrypt(paprastas_tekstas.encode())
        return b64encode(iv + sifruotas_tekstas).decode("utf-8")

    def decrypt(self, sifruotas_tekstas):
        sifruotas_tekstas = b64decode(sifruotas_tekstas)
        iv = sifruotas_tekstas[:self.bloko_dydis]
        sifras = AES.new(self.raktas, AES.MODE_CBC, iv)
        paprastas_tekstas = sifras.decrypt(sifruotas_tekstas[self.bloko_dydis:]).decode("utf-8")
        return self.__unpad(paprastas_tekstas)

    def __pad(self, paprastas_tekstas):
        kiekis_baitu = self.bloko_dydis - len(paprastas_tekstas) % self.bloko_dydis
        ascii_string = chr(kiekis_baitu)
        patvarkytas_str = kiekis_baitu * ascii_string
        padded_plain_text = paprastas_tekstas + patvarkytas_str
        return padded_plain_text

    @staticmethod
    def __unpad(paprastas_tekstas):
        paskutine_raide = paprastas_tekstas[len(plain_text) - 1:]
        return paprastas_tekstas[:-ord(paskutine_raide)]