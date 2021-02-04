
class cryptography:
    def __init__(self):
        self.encrypted = None
        self.key = None
        self.decrypted = None

    def ceasar_encryption(self, text, key):
        abc_upper = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
        abc_down = 'abcdefghijklmnopqrstuvwxyz'
        string = ''
        def isValid(a, b): return True if (a + b) <= 26 else False
        for x in text:
            if x.isalpha():
                if x.isupper():
                    index = abc_upper.find(x)
                    string += abc_upper[index + key % 26]
                else:
                    index = abc_down.find(x)
                    string += abc_down[index + key % 26]
            else:
                string += x
        return string


kripto = cryptography()
print(kripto.ceasar_encryption("Labas Pasauli", 3))
