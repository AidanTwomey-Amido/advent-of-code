

  "DoHickey":[
    {
      "Authority": "next.co.uk/api/identity",
      "AllowedAudiences":[
        "first",
        "second"
      ]
    },
    {
      "Authority": "identity.next.co.uk",
      "AllowedAudiences":[
        "another one"
      ]
      
    }
  ],

  "AlternativeHickey":[
    {
      "Audience": "next.co.uk", // maps to host
      "Authority": [
        "next.co.uk/api/identity",
        "identity.next.co.uk"
      ]
    },
    {
      "Audience": "childsplay.co.uk",
      "Authority": [
        "next.co.uk/api/identity",
        "identity.childsplay.co.uk"
      ]
    }
  ]