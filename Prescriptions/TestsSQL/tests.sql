-- test 1 for POST - prescription added for an existing patient
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 1
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-29T10:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 1,
      "name": "Aspirin",
      "description": "Take with food",
      "dose": 2
    },
    {
      "idMedicament": 3,
      "name": "Paracetamol", 
      "description": "As needed for pain",
      "dose": 1
    }
  ]
}

-- test 2 for POST - prescription added for a new patient
{
  "patient": {
    "idPatient": 0,
    "firstName": "Alice",
    "lastName": "Cooper",
    "birthDate": "1985-03-20T00:00:00"
  },
  "doctor": {
    "idDoctor": 2
  },
  "date": "2024-05-22T14:00:00",
  "dueDate": "2024-06-05T14:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 5,
      "name": "Lisinopril",
      "description": "Take daily with breakfast",
      "dose": 1
    }
  ]
}