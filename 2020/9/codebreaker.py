import numpy as np


def firstElementNotSumOfTwoPreviousElements(numbers, preamble_length):
    for i in np.arange(preamble_length, len(numbers)):
        if isElementSumOfTwoPreviousElements(numbers, i, preamble_length):
            print(i)
        else:
            return numbers[i]
    return 0


def isElementSumOfTwoPreviousElements(numbers, index, preamble_length):
    current_element = numbers[index]

    sub_numbers = numbers[index - preamble_length:index]

    for i in np.arange(0, preamble_length):
        for j in np.arange(0, preamble_length):
            if i != j:
                #print(f'{sub_numbers[i]}, {sub_numbers[j]}')
                if current_element == sub_numbers[i] + sub_numbers[j]:
                    return True
    return False
