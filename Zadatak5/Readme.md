# Pitanje 1:
Izvođenje programa trajalo je 5 sekundi.

# Pitanje 2:
Operacije A,B,C,D,E su se sve izvodile na jednoj dretvi(1).

# Pitanje 3:
Sada je izvođenje programa trajalo 1,13 sekundi.

# Pitanje 4:
Sve operacije su se izvodile na svojoj dretvi tj. sveukupno na 5 dretvi.

# Pitanje 5:
Neželjeno ponašanje nastaje uslijed istovremenog pristupa. Kada jedna dretva dohvati varijablu i poveća je za 1 
(nije ju još spremila) tada druga istovremeno može dohvatiti varijablu tj. njezinu staru vrijednost te se zapravo 
gubi povećavanje prve dretve. Prva dretva spremi varijablu, ali sljedeća sprema opet tu istu vrijednost jer nije 
dohvatila varijablu nakon povećanja.

