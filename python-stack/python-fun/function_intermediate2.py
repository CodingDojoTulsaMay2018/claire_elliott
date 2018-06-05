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

iterateDict(students)