export default function Botao({text, className, submit, onClick}) {
    return (
       <button
       type={submit ? 'submit' : null}
       onClick={onClick}
       className={`${className}`}
       >
          {text}
       </button>
    );
}