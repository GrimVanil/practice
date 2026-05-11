import re

with open("result.txt", "r", encoding="utf-8") as file:
    text = file.read()

match = re.search(r"\d+(\.\d+)?", text)

if match:
    print("OK")
else:
    print("ERROR")