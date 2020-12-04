import pytest

from importlib.machinery import SourceFileLoader

mymodule = SourceFileLoader('passport_reader', '../passport_reader.py').load_module()


def test_add_record_to_dictionary():
    records = mymodule.createCredentialsSet(["ecl:gry", "pid:860033327"])
    assert records["ecl"] == "gry"
    assert records["pid"] == "860033327"


goodCredentials = [
    "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm",
    "hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm",
    """hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm"""
]


@pytest.mark.parametrize("test_input", goodCredentials)
def test_when_credential_is_valid_return_true(test_input):
    assert mymodule.isRecordValid(test_input)


badCredentials = [
    "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929",
    "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in"
]


@pytest.mark.parametrize("test_input", badCredentials)
def test_eval(test_input):
    assert mymodule.isRecordValid(test_input) == False


def test_many_credentials_get_counted():
    input = """ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm"""

    count = mymodule.countValidCredentials(input)

    assert count == 2


goodAttributes = [
    ("byr", "2000")
]


@pytest.mark.parametrize("attribute,value", goodAttributes)
def test_eval(attribute, value):
    assert mymodule.isAttributeValid(attribute, value)


badAttributes = [
    ("byr", "1900")
]


@pytest.mark.parametrize("attribute,value", badAttributes)
def test_eval(attribute, value):
    assert not mymodule.isAttributeValid(attribute, value)
