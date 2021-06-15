import React, { useState, useEffect } from 'react'
import {Form, FormGroup, Label, Input, Col, Row, Button } from 'reactstrap'
import {ChildForm} from "./ChildForm"


export const PassportForm = () => {
  const [passportData, setPassportData] = useState(
    {
      secondName: "",
      firstName: "",
      patronymic: "Menovich",
      series: "8241",
      number: "352478",
      issuePlace: "ГУ МВД России",
      issueDate: "",
      unitNumber: "",
    });


  const [childData, setChildData] = useState([]);

  const addChildData = (e, data) => {
    e.preventDefault();
    setChildData(prevData => {
      return [
        ...prevData,
        data[0]
      ]
    })
    
  }

  // const [childBlocks, setChildBlocks] = useState([
  //   <ChildForm id={childBlockCount} getChildData={getChildData}/>
  // ]);


  const saveData = (content, fileName, contentType) => {
    var a = document.createElement("a");
    var file = new Blob([content], {type: contentType});
    a.href = URL.createObjectURL(file);
    a.download = fileName;
    a.click();
  }

  const isObjectEmpty = (obj) => {
    return Object.keys(obj).length === 0;
  }

  var openFile = () => {
    var input = document.getElementById("upload_file");

    var reader = new FileReader();
    reader.onload = function() {
      var text = reader.result;
      var jsonObj = JSON.parse(text);
      setPassportData(jsonObj.passport);
      if (!isObjectEmpty(jsonObj.children)) {
        for (const value of Object.values(jsonObj.children)) {
          setChildData((prevData) => {
            return [
              ...prevData,
              value
            ]
          })
        }
      }
    };
    reader.readAsText(input.files[0]);
  };

  const click = () => {
    document.getElementById("upload_file_label").click();
  }

  const is_fields_empty = () => {
    var inputs = document.getElementsByClassName("verifiable");
    //var data = Array.from(inputs, e => e.value);

    for (var i = 0; i < inputs.length; i++) {
      if (inputs[i].value === "") {
        //console.log("Hey");
        return true;
      }
    }
    return false;
  }

  const validate_form = () => {
    document.querySelector('#secondName').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
    document.querySelector('#firstName').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
    document.querySelector('#patronymic').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я]/g, '');
    });
    document.querySelector('#series').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^\d]/g, '');
    });
    document.querySelector('#number').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^\d]/g, '');
    });
    document.querySelector('#issuePlace').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^A-zА-я ]/g, '');
    });
    document.querySelector('#unitNumber').addEventListener('keyup', function(){
      this.value = this.value.replace(/[^\d]/g, '');
    });
  }

  const axios = require('axios');

  const onSubmit = e => {
    e.preventDefault();

    validate_fields()

    if (is_fields_empty()) {
      //alert("Заполните все поля");
    }
    else {
      axios.post('/addPassport', 
      {
        passport: {...passportData},
        children: {...childData}
      }).then(res => {
        //console.log(res)
      }); // Результат ответа от сервера
    }
  }

  const validate_fields = () => {
    var inputs = document.getElementsByClassName("verifiable");

    for (var i = 0; i < inputs.length; i++) {
      if (inputs[i].value === "") {
        inputs[i].placeholder = " ";
        
      }
    }
  }

  useEffect(validate_form);

  return (
    <div>
        {/* {validate_form} */}
        <Form className="form">
          <Row form>
            <Col>
              <FormGroup>
                <Label for="secondName">Фамилия</Label>
                <Input className="verifiable" type="text" name="secondName" id="secondName" 
                  onChange={(e) => setPassportData({...passportData, ...{[e.target.name]: e.target.value}})} 
                  required value={passportData.secondName} placeholder=""/>
                  <span className="tooltip">Введите Вашу фамилию!</span>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="FirstName">Имя</Label>
                <Input className="verifiable" type="text" name="FirstName" id="firstName"
                onChange={(e) => setPassportData({...passportData, ...{firstName: e.target.value}})}
                 required value={passportData.firstName} placeholder=""/>
                 <span className="tooltip">Введи Ваше имя!</span>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="patronymic">Отчество</Label>
                <Input  type="text" name="patronymic" id="patronymic" 
                onChange={(e) => setPassportData({...passportData, ...{patronymic: e.target.value}})}
                 required value={passportData.patronymic} placeholder=""/>
                 {/* <span className="tooltip">Введите Ваше отчество</span> */}
              </FormGroup>
            </Col>
          </Row>
          <Row>
            <Col>
              <FormGroup>
                <Label for="series">Серия</Label>
                <Input className="verifiable" type="text" name="series" id="series" 
                onChange={(e) => setPassportData({...passportData, ...{series: e.target.value}})}
                required value={passportData.series} 
                maxLength="4"/>
                <span className="tooltip">Введите серию паспорта!</span>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="number">Номер</Label>
                <Input className="verifiable" type="text" name="number" id="number" 
                onChange={(e) => setPassportData({...passportData, ...{number: e.target.value}})}
                required value={passportData.number} 
                maxLength="6"/>
                <span className="tooltip">Введите номер паспорта!</span>
              </FormGroup>
            </Col>
          </Row>
          <FormGroup>
            <Label for="issuePlace">Кем выдан</Label>
            <Input className="verifiable" type="text" name="issuePlace" id="issuePlace" 
            onChange={(e) => setPassportData({...passportData, ...{issuePlace: e.target.value}})}
            required value={passportData.issuePlace} />
            <span className="tooltip">Введите место выдачи!</span>
          </FormGroup>
          <Row>
            <Col>
              <FormGroup>
                <Label for="issueDate">Дата выдачи</Label>
                <Input className="verifiable" type="date" name="issueDate" id="issueDate"
                onChange={(e) => setPassportData({...passportData, ...{issueDate: e.target.value}})}
                 required value={passportData.issueDate} />
                 <span className="tooltip">Введи дату выдачи паспорта, пожалуйста!</span>
              </FormGroup>
            </Col>
            <Col>
              <FormGroup>
                <Label for="unitNumber">Номер подразделения</Label>
                <Input className="verifiable" type="text" name="unitNumber" id="unitNumber" 
                onChange={(e) => setPassportData({...passportData, ...{unitNumber: e.target.value}})}
                 value={passportData.unitNumber} required minLength="6"
                 maxLength="6" placeholder=""/>
                 <span className="tooltip">Введи номер подразделения, пожалуйста!</span>
              </FormGroup>
              
              <Input type='file' id='upload_file' 
              onChange={ () => {
                openFile()
              }}/>
            </Col>
          </Row>
          <Button type="submit" color="primary" onClick={onSubmit}>Отправить</Button>
          <Button type="button" color="primary" 
          href={"/download/" + passportData.series + "/" +
           passportData.number}>Экспорт в Excel</Button>
          </Form>
          
          <h5 className="childrenHeader">Дети:</h5>
          {childData.map((item, i) => (
            <ChildForm key={i} dataItem={item} onChange={item => setChildData(items => {
              items.splice(i, 1, {...item});
              return [
                ...items
              ]
            })} getChildData={addChildData}/>
          ))}
          
          <Button outline type="button" color="primary" onClick={() => setChildData(prevBlocks => {
            return [
              ...prevBlocks,
              {
                childSecondName: "",
                childFirstName: "",
                childPatronymic: "",
                childBirthDate: "",
              }
            ]
          })}>Добавить ребенка</Button>
          <Button outline type="button" color="primary" onClick={() => setChildData(prevBlocks => {
            var blocks = [...prevBlocks];
            blocks.splice(-1, 1);
            return blocks;
          })}>Удалить ребенка</Button><br></br>
          <div className="separator"></div>
          
          <Button type="button" color="primary" onClick={() => {
            var jsonData = 
            {
              passport: {...passportData},
              children: {...childData}
            }
            saveData(JSON.stringify(jsonData), 'json.txt', 'text/plain')
          }}>Сохранить данные</Button>
          <Button type="button" color="primary" 
          onClick={click}
          >Загрузить данные</Button>
          <Label id="upload_file_label" for="upload_file" hidden>Загрузить данные</Label>
    </div>
  )
}