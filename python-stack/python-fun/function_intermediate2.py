x = [ [5,2,3], [10,8,9] ] 
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

# How would you change the value 10 in x to 15?  Once you're done x should then be [ [5,2,3], [15,8,9] ].  
x[1][0] = 15

# How would you change the last_name of the first student from 'Jordan' to "Bryant"?
students[0]["last_name"] = "Jordan"

# For the sports_directory, how would you change 'Messi' to 'Andres'?
sports_directory["soccer"][0] = "Andres"

# For x, how would you change the value 20 to 30?

# 2. Create a function that given a list of dictionaries, it loops through each dictionary in the list and prints each key and the associated value.  For example, given the following list:

def iterateDict(students):
    for student in students:
        print(", ".join('{} - {}'.format(k, v) for k,v in student.items()))


# 3. Create a function that given a list of dictionaries and a key name, it outputs the value stored in that key for each dictionary.  For example, iterateDictionary2('first_name', students) should output
def iterKeys(key_name,dict_list):
    for item in dict_list:
        print(item[key_name])

# 4. Create a function that prints the name of each location and also how many locations the Dojo currently has.  Have the function also print the name of each instructor and how many instructors the Dojo currently has.  For example, printDojoInfo(dojo) should output

dojo = {
   'location': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}

def printDojoInfo(dojo):
    for item in dojo:
        print('{} {}'.format((len(dojo[item])),item.upper()))
        for i in dojo[item]:
            print('{}'.format(i))
        print("\n")