let x = 0;

function addInput() {
    var str = '<FormGroup className="childrenBlock"> <Row> <Col> <FormGroup> <Label for="childrenSecondName">Фамилия</Label> <Input type="text" name="childrenSecondName" id="childrenSecondName" required/> </FormGroup> </Col> <Col> <FormGroup> <Label for="childrenFirstName">Имя</Label> <Input type="text" name="childrenFirstName" id="childrenFirstName" required/> </FormGroup> </Col> <Col> <FormGroup> <Label for="childrenPatronymic">Отчество</Label> <Input type="text" name="childrenPatronymic" id="childrenPatronymic" required/> </FormGroup> </Col> </Row> <FormGroup> <Label for="childrenPatronymic">Пол:</Label> </FormGroup> <FormGroup row> <FormGroup check className="radioMale"> <Label check> <Input type="radio" name="genderRadio" />{" "} Мужской </Label> </FormGroup> <FormGroup check> <Label check> <Input type="radio" name="genderRadio" />{" "} Женский </Label> </FormGroup> </FormGroup> <Row> <Col> <FormGroup> <Label for="issueDate">Дата рождения</Label> <Input type="date" name="issueDate" id="issueDate" required/> </FormGroup> </Col> <Col> </Col> </Row> </FormGroup>';
    document.getElementById('input' + x).innerHTML = str;
    x++; 
}