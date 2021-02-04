'''
GITHUB:
@CypressG 

Bene vienas paprasčiausių kriptografijos koduočių, kurį sukūrė Gajus Julius Cezaris

Kaip čia viskas veikia:
- Inicijuojat klase (pvz kripto = Caesar())
- Pasirenkat metoda ir duodat metodui reikiamus parametrus

Encryption metodas
    Leidžia užšifruoti tekstą

klases_pavadinimas.encryption("Tekstas_kuri_norime_paslepti",RAKTAS_TIK_SKAICIUS)
pvz:
    kripto.encryption("Labas Pasauli 1923", 35)

Decryption
Leidžia atšifruoti tekstą su pasirinktu(žinomu) raktu
    pvz:
        print(kripto.decryption("Mącąš Qąšąųmį 6478", 35))
Brute Force
Nežinant rakto išbando raktus nuo JŪSŲ_PASIRINKTOS_PRADŽIOS iki JŪSŲ_PASIRINKTOS_PABAIGOS
su nurodytu žingsniu ir viską įrašo į failą.
pvz:
    print(kripto.brute_force("Mącąš Qąšąųmį 6478",0,50,1))
'''


ABC_UPPER = 'AĄBCČDEĘĖFGHIĮJKLMNOPQRŠTUŲŪVWXYZŽ'
ABC_DOWN = 'aąbcčdeęėfghiįjklmnopqrsštuųūvwxyzž'
SYMBOLS = "!@#$%^&*()-_+/.,<>~ ᴪ𝞐𝒚β"

KEY_LENGTH = len(ABC_UPPER)
SYMBOLS_LENGTH = len(SYMBOLS)


class Caesar:
    def __init__(self, text):
        self.encrypted_text = text
        self.decrypted_text = ''
        pass

    def encryption(self, text, key):
        string = ''
        for x in text:
            if x in ABC_UPPER or x in ABC_DOWN:
                if x.isupper():
                    index = ABC_UPPER.find(x)
                    string += ABC_UPPER[index + key % KEY_LENGTH]
                else:
                    index = ABC_DOWN.find(x)
                    string += ABC_DOWN[index + key % KEY_LENGTH]
            elif x.isdigit():
                number = (int(x) + key) % 10
                string += str(number)
            else:
                index = SYMBOLS.find(x)
                string += SYMBOLS[(index + key) % SYMBOLS_LENGTH]
        self.encrypted_text = string
        return string

    def decryption(self, text, key):
        string = ''
        for x in text:
            if x in ABC_UPPER or x in ABC_DOWN:
                if x.isupper():
                    index = ABC_UPPER.find(x)
                    string += ABC_UPPER[(index - key) % KEY_LENGTH]
                else:
                    index = ABC_DOWN.find(x)
                    string += ABC_DOWN[(index - key) % KEY_LENGTH]
            elif x.isdigit():
                number = (int(x) - key) % 10
                string += str(number)
            else:
                index = SYMBOLS.find(x)
                string += SYMBOLS[(index - key) % SYMBOLS_LENGTH]
        return string

    def brute_force(self, text, iteration_start, iteration_end, step):
        iterations = iteration_end - iteration_start
        with open(f"brute_force_{iterations}.txt", "w") as file:
            for x in range(iteration_start, iteration_end, step):
                file.write(f"{x} - " + self.decryption(text, x) + "\n")
            return True
        return False

    def brute_force_chain(self, text, key, iterations):
        with open(f"brute_force_chain_{iterations}.txt", "w") as file:
            new = self.decryption(text, key)
            file.write(f"{0} - " + new + "\n")
            for x in range(iterations - 1):
                new = self.decryption(new, key)
                file.write(f"{x+1} - " + new + "\n")
            return True
        return False


kryptos = Caesar(text="Kipras")
for x in range(3):
    print(kryptos.encryption(text=kryptos.encrypted_text, key=3))

print(kryptos.brute_force_chain(text="Tqvxfy", key=3, iterations=10))
