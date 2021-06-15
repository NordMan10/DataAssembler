import React, { useEffect } from 'react'
import { Form, FormGroup, Label, Input, Col, Row } from 'reactstrap'

export const ChildForm = (props) => {

  const handleInputOnChange = (e) => {
    props.onChange({...props.dataItem, ...{[e.target.name]: e.target.value }})
  }

  const validate_form = () => {
    document.querySelector('#childSecondName').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
    document.querySelector('#childFirstName').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
    document.querySelector('#childPatronymic').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
  }

  useEffect(() => {
    var entries = Object.entries(props.dataItem);
    var gender = "";

    entries.map(([key, value]) => {
      if (key === "childGender") {
        gender = value;
      }
      return true;
    })
    
    if (gender === "male") {
      document.getElementById("maleGender").setAttribute("checked", "checked");
      document.getElementById("femaleGender").removeAttribute("checked");
    }
    else if (gender === "female") {
      document.getElementById("femaleGender").setAttribute("checked", "checked");
      document.getElementById("maleGender").removeAttribute("checked");
    }
  })

  useEffect(validate_form);

  return (
    <div>
      <Form id="child_form">
        <FormGroup className={"childrenBlock"}>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="childSecondName">Фамилия</Label>
                  <Input  type="text" name="childSecondName" id="childSecondName"
                  onChange={(e) => handleInputOnChange(e)}
                  required value={props.dataItem.childSecondName} />
                </FormGroup>
              </Col>
              <Col>
                <FormGroup>
                  <Label for="childFirstName">Имя</Label>
                  <Input className="verifiable" type="text" name="childFirstName" id="childFirstName" 
                  onChange={(e) => handleInputOnChange(e)}
                  required value={props.dataItem.childFirstName}/>
                </FormGroup>
              </Col>
              <Col>
                <FormGroup>
                  <Label for="childPatronymic">Отчество</Label>
                  <Input className="verifiable" type="text" name="childPatronymic" id="childPatronymic" 
                  onChange={(e) => handleInputOnChange(e)}
                  required value={props.dataItem.childPatronymic}/>

                </FormGroup>
              </Col>
            </Row>
            <FormGroup>
              <Label for="radioMale">Пол:</Label>
            </FormGroup>
            <FormGroup row>
              <FormGroup check className="radioMale">
                <Label check>
                  <Input className="verifiable" type="radio" id={"maleGender"} name={"childGender"}
                  onChange={(e) =>  handleInputOnChange(e)}
                  value="male" />
                  Мужской
                </Label>
              </FormGroup>
              <FormGroup check>
                <Label check>
                  <Input className="verifiable" type="radio" id={"femaleGender"} name={"childGender"}
                  onChange={(e) =>  handleInputOnChange(e)}
                  value="female"  />
                  Женский
                </Label>
              </FormGroup>
            </FormGroup>
            <Row>
              <Col>
                <FormGroup>
                  <Label for="childBirthDate">Дата рождения</Label>
                  <Input className="verifiable" type="date" name="childBirthDate" id="childBirthDate" required 
                  onChange={(e) =>  handleInputOnChange(e)} value={props.dataItem.childBirthDate}
                  placeholder=" "/>
                </FormGroup>
                <ul>
                  { 
                    Object.values(props.dataItem).map((value, i) => {
                        return <li key={i}>{value}</li>
                      })
                    
                    
                  }
                </ul>
              </Col>
            </Row>
          </FormGroup>
      </Form>
    </div>   
  )

}