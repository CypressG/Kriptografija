'''
GITHUB:
@CypressG 


This task is done only using ASCII letters but the possibility of using foreign 
letters is as well possible by refactoring some code and butting your own custom alphabet
inside of array. 


HOW TO USE IT?

So, for the first part You have to decide if you're using your own CUSTOM ALPHABET or either you use
unicode
'''


CUSTOM_ALPHABET = "AĄBCČDEĘĖFGHIĮJKLMNOPQRŠTUŲŪVWXYZŽ"

# If you're using CUSTOM_ALPHABET instead of UNICODE use len(CUSTOM_ALPHABET) instead of 122
LENGTH = 122


class Vigenere:

    def __init__(self, plaintext, cipherkey):
        self.plaintext = plaintext
        self.cipherkey = cipherkey
        self.extended()

    def encryption(self):
        self.encrypted = ''
        for x in range(len(self.plaintext)):
            self.encrypted += self.single_encryption_unicode(
                ord(self.plaintext[x]), ord(self.cipherkey[x]), LENGTH)
        return print(self.encrypted)

    def decryption(self, *args):
        self.decrypted = ''
        if len(args) == 2:
            self.encrypted = args[0]
            self.extended(args[1])
        for x in range(len(self.encrypted)):
            # If you would like to change decryption change from _unicode to _custom
            self.decrypted += self.single_decryption_unicode(
                ord(self.encrypted[x]), ord(self.cipherkey[x]), LENGTH)
        return self.decrypted

    def single_decryption_unicode(self, value, key, number_of_letters):
        decrypted_letter = (value - key) % number_of_letters
        return chr(decrypted_letter)

    def single_encryption_unicode(self, value, key, number_of_letters):
        encrypted_letter = (value + key) % number_of_letters
        return chr(encrypted_letter)

    def single_encryption_custom(self, value, key, number_of_letters):
        encrypted_letter = (value + key) % number_of_letters
        return CUSTOM_ALPHABET[encrypted_letter]

    #Extends the length of cipherkey 
    def extended(self, *args):
        counter = 0
        if len(args) == 1:
            self.cipherkey = args[0]
        while(len(self.plaintext) > len(self.cipherkey)):
            self.cipherkey += self.cipherkey[counter]
            counter += 1


krypto = Vigenere(plaintext="attack", cipherkey="def")

krypto.encryption()
print(krypto.decryption("K_`KNW", "def"))
