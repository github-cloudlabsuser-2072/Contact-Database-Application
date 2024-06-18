def add(num1, num2):
    return num1 + num2

def subtract(num1, num2):
    return num1 - num2

def multiply(num1, num2):
    return num1 * num2

def divide(num1, num2):
    if num2 != 0:
        return num1 / num2
    else:
        return "Error: Division by zero is not allowed."

# Test the calculator functions
print(add(5, 3))
print(subtract(10, 7))
print(multiply(4, 6))
print(divide(15, 3))