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
Nežinant rakto išbando raktus nuo JŪSŲ_PASIRINKTOS_PRADŽIOS iki JŪSŲ_PASIRINKTOS_PABAIGOS bei nurodyti turite žingsnį.
pvz:
    print(kripto.brute_force("Mącąš Qąšąųmį 6478",0,50,1))
'''
ABC_UPPER = 'AĄBCČDEĘĖFGHIĮJKLMNOPQRŠTUŲŪVWXYZŽ'
ABC_DOWN = 'aąbcčdeęėfghiįjklmnopqrsštuųūvwxyzž'
KEY_LENGTH = len(ABC_UPPER)
class Caesar:
    def __init__(self):
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
                string+= str(number)
            else:
                string+=x
        return string

    def decryption(self,text,key):
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
                string+= str(number)
            else:
                string+=x
        return string

    def brute_force(self,text,iteration_start,iteration_end, step):
        iterations = iteration_end - iteration_start
        with open(f"brute_force_{iterations}.txt","w") as file:
            for x in range(iteration_start, iteration_end, step):
                file.write(f"{x} - " + self.decryption(text,x) + "\n")
        return True

kripto = Caesar()
print(kripto.encryption("Labas Pasauli 1923", 35))
print(kripto.decryption("Mącąš Qąšąųmį 6478", 35))
print(kripto.brute_force("Mącąš Qąšąųmį 6478",0,50,1))