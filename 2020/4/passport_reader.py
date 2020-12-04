import re

def countValidCredentials(northPoleCredentials):
    total = 0

    for credential in northPoleCredentials.split("\n\n"):
        if isRecordValid(credential):
            total += 1

    return total


def isRecordValid(northPoleCredential):
    flatLine = northPoleCredential.replace("\n", " ")

    records = createCredentialsSet(flatLine.split(" "))

    return ("ecl" in records) and ("pid" in records) and ("hgt" in records) and ("eyr" in records) and (
                "hcl" in records) and ("byr" in records) and ("iyr" in records)


def createCredentialsSet(credentialPairs):
    records = {}

    for credential in credentialPairs:
        pair = credential.split(':')
        if isAttributeValid(pair[0], pair[1]):
            records[pair[0]] = pair[1]

    return records


def isAttributeValid(key, attributeValue):
    allowedEyeColous = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"]


    if key == "byr":
        if (len(attributeValue) == 4) and (int(attributeValue) > 1919) and (int(attributeValue) < 2003):
            return True


    if key == "iyr":
        if (len(attributeValue) == 4) and (int(attributeValue) > 2009) and (int(attributeValue) < 2021):
            return True

    if key == "eyr":
        if (len(attributeValue) == 4) and (int(attributeValue) > 2019) and (int(attributeValue) < 2031):
            return True

    if key == "hgt":
        if (len(attributeValue) == 5):
            if (attributeValue[3] == "c") and (attributeValue[4] == "m"):
                heightInCm = int(attributeValue[: 3])
                return (heightInCm > 149) and (heightInCm < 194)

        if (len(attributeValue) == 4):
            if (attributeValue[2] == "i") and (attributeValue[3] == "n"):
                heightInIn = int(attributeValue[: 2])
                return (heightInIn > 58) and (heightInIn < 77)

    if key == "hcl":
        if (attributeValue[0] == '#') and (len(attributeValue) == 7):
            colourCode = attributeValue[1:]
            return re.match("^[a-f0-9]*$", colourCode)

    if key == "ecl":
        return attributeValue in allowedEyeColous

    if key == "pid":
        return len(attributeValue) == 9

    if key == "cid":
        return True

    return False
