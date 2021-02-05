from abc import ABC
import abc


TEXT = "Hello World!"


class Vigenere:

    def __init__(self, plaintext, cipherkey):
        self.plaintext = plaintext
        self.cipherkey = cipherkey

    def encryption(self, plaintext, cipherkey):
        answer = ''
        for x in plaintext:

    def range_ascii(self):
        start = 1
        for x in range(65, 91, 1):
            print(f"{start} - {x} - {chr(x)}")
            start += 1

    def extended(self):
        while(len(plaintext) > len(cipherkey)):
            print()


krypto = Vigenere(plaintext=None, cipherkey=None)
krypto.encryption("Kipras4123", "kipras")
