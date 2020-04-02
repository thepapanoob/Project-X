const fs = require('fs');
const path = require('path');

const INCLUDEMARKER = `{{ include `;
const ENDMARKER = ` }}`;

const fileContent = fs.readFileSync(path.join(__dirname, 'launcher.cs')).toString();

const checkFile = file => {
    return new Promise((resolve, reject) => {
        fs.access(file, fs.constants.F_OK | fs.constants.R_OK, err => {
            resolve(err ? false : true);
      });
    });
};

const xmlResolver = content => {

};

const includeResolver = async (content, start) => {
    let outputfile = '';

    const includeMarkerPos = content.indexOf(INCLUDEMARKER, start);
    
    if (includeMarkerPos !== -1)
    {
        outputfile += content.substr(start, includeMarkerPos - start);

        const endMarkerPos = content.indexOf(ENDMARKER, includeMarkerPos);
        const filename = content.substr(includeMarkerPos + INCLUDEMARKER.length, endMarkerPos - includeMarkerPos - INCLUDEMARKER.length);
        console.log(`Trying to resolve ${filename}`);

        const fileGucci = await checkFile(path.join(__dirname, filename));
        if (fileGucci)
        {
            outputfile += fs.readFileSync(path.join(__dirname, filename)).toString();
            console.log(`resolved ${filename}!`);
        } else {
            console.log(`could not resolve ${filename}!`);
        }
        
        outputfile += await includeResolver(content, endMarkerPos + ENDMARKER.length);
    } else {
        outputfile += content.substr(start, content.length - start);
    }
    
    return outputfile;
};

const runTemplate = async (content) => {
    let actualFile = content;
    while (actualFile.includes('{{ ') && actualFile.includes(' }}'))
    {
        actualFile = await includeResolver(actualFile, 0);
    }

    fs.writeFileSync(path.join(__dirname, 'launcher_build.cs'), actualFile);
    console.log('Done!');
};

runTemplate(fileContent);