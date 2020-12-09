import pytest

from importlib.machinery import SourceFileLoader

decrypt_module = SourceFileLoader('codebreaker', '../codebreaker.py').load_module()

numbers = [35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576]

goodCredentials = [5]

@pytest.mark.parametrize("test_input", goodCredentials)
def test_element_is_sum_of_two_previous_elements(test_input):
    assert decrypt_module.isElementSumOfTwoPreviousElements(numbers, test_input, 5) == True

def test_element_is_sum_of_two_previous_elements_long_sequence():
    long_numbers = [3,	48,	30,	21,	18,	50,	9,	37,	5,	31,	17,	39,	14,	45,	27,	23,	2,	4,	19,	35,	10,	32,	33,	28,	7,	34,	11,	6,	8]
    assert decrypt_module.isElementSumOfTwoPreviousElements(long_numbers, 28, 25) == True

def test_element_is_not_sum_of_two_previous_elements():
    assert decrypt_module.isElementSumOfTwoPreviousElements(numbers, 14, 5) == False

def test_firest_element_that_is_sum_of_two_previous_elements():
    assert decrypt_module.firstElementNotSumOfTwoPreviousElements(numbers, 5) == 127

#
# goodCredentials = [
#     "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm",
#     "hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm",
#     """hcl:#ae17e1 iyr:2013
# eyr:2024
# ecl:brn pid:760753108 byr:1931
# hgt:179cm"""
# ]
#
#
# @pytest.mark.parametrize("test_input", goodCredentials)
# def test_when_credential_is_valid_return_true(test_input):
#     assert mymodule.isRecordValid(test_input)
#
#
# badCredentials = [
#     "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929",
#     "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in"
# ]
#
#
# @pytest.mark.parametrize("test_input", badCredentials)
# def test_eval(test_input):
#     assert mymodule.isRecordValid(test_input) == False
#
#
# def test_many_credentials_get_counted():
#     input = """ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
# byr:1937 iyr:2017 cid:147 hgt:183cm
#
# iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
# hcl:#cfa07d byr:1929
#
# hcl:#ae17e1 iyr:2013
# eyr:2024
# ecl:brn pid:760753108 byr:1931
# hgt:179cm"""
#
#     count = mymodule.countValidCredentials(input)
#
#     assert count == 2
#
#
# goodAttributes = [
#     ("byr", "2000")
# ]
#
#
# @pytest.mark.parametrize("attribute,value", goodAttributes)
# def test_eval(attribute, value):
#     assert mymodule.isAttributeValid(attribute, value)
#
#
# badAttributes = [
#     ("byr", "1900")
# ]
#
#
# @pytest.mark.parametrize("attribute,value", badAttributes)
# def test_eval(attribute, value):
#     assert not mymodule.isAttributeValid(attribute, value)
