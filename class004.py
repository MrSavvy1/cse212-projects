with open("products.csv", "r") as file:
    data = file.readlines()
    for line in data:
        word = line.split()
        print(word)

with open("products.csv", "r") as file:
    file.write("This will add this product to file")
    file.close()


import os

if os.path.exists("Products.csv"):
    os.remove("product.csv")
else:
    print("does not exist")