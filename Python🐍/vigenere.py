'''

This task is done only using ASCII letters but the possibility of using foreign 
letters is as well possible by refactoring some code and butting your own custom alphabet
inside of array. 

'''


#CUSTOM_ALPHABET = "AĄBCČDEĘĖFGHIĮJKLMNOPQRŠTUŲŪVWXYZŽ"


LETTERS = [x for x in range(65, 91, 1)]
LETTERS_LENGTH = len(LETTERS)
SYMBOLS = [x for x in range(33, 48, 1)]
SYMBOLS_LENGTH = len(SYMBOLS)
DIGITS = [x for x in range(48, 58, 1)]
DIGITS_LENGTH = len(DIGITS)

ALL_INCLUDED = 127 - 33


class Vigenere:

    def __init__(self, plaintext, cipherkey):
        self.plaintext = plaintext
        self.cipherkey = cipherkey
        self.extended()
        self.encryption()
        self.decryption(self.encrypted, "kipras123k")

    def encryption(self):
        self.encrypted = ''
        for x in range(len(self.plaintext)):
            value_letter = ord(self.plaintext[x])
            key_letter = ord(self.cipherkey[x])
            self.encrypted += chr(self.single_encryption_ascii(
                value_letter, key_letter, ALL_INCLUDED, 33))

    def decryption(self, encrypted_text, key):
        self.decrypted = ''

        for x in range(len(encrypted_text)):
            value_letter = ord(encrypted_text[x])
            key_letter = ord(key[x])
            self.decrypted += chr(self.single_decryption_ascii(
                value_letter, key_letter, ALL_INCLUDED, 33))

    def single_decryption_ascii(self, value, key, number_of_letters, position):
        decrypted_letter = (value - key) % number_of_letters
        print(decrypted_letter)
        return decrypted_letter

    def single_encryption_ascii(self, value, key, number_of_letters, position):
        encrypted_letter = ((value + key) % number_of_letters) + position
        return encrypted_letter

    def single_encryption_custom(self, value, key, number_of_letters):
        encrypted_letter = ((value + key) % number_of_letters)
        return encrypted_letter

    def extended(self):
        counter = 0
        while(len(self.plaintext) > len(self.cipherkey)):
            self.cipherkey += self.cipherkey[counter]
            counter += 1


krypto = Vigenere(plaintext="Kipras4123", cipherkey="kipras123")
print(krypto.cipherkey)
print(krypto.encrypted)
print(krypto.decrypted)
